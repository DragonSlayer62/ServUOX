using System;
using System.Collections.Generic;
using System.Linq;
using Server.Spells;

namespace Server.Items
{
    public class WhirlwindAttack : WeaponAbility
    {
        public WhirlwindAttack()
        {
        }

        public override int BaseMana => 15;

        public static List<WhirlwindAttackContext> Contexts { get; set; }

        public override bool OnBeforeDamage(Mobile attacker, Mobile defender)
        {
            if (attacker.Weapon is BaseWeapon wep)
                wep.ProcessingMultipleHits = true;

            return true;
        }

        public override void OnHit(Mobile attacker, Mobile defender, int damage)
        {
            if (!Validate(attacker) || (Contexts != null && Contexts.Any(c => c.Attacker == attacker)))
                return;

            ClearCurrentAbility(attacker);

            Map map = attacker.Map;

            if (map == null)
                return;


            if (!(attacker.Weapon is BaseWeapon weapon))
                return;

            if (!CheckMana(attacker, true))
                return;

            attacker.FixedEffect(0x3728, 10, 15);
            attacker.PlaySound(0x2A1);

            var list = SpellHelper.AcquireIndirectTargets(attacker, attacker, attacker.Map, 1)
                .OfType<Mobile>()
                .Where(m => attacker.InRange(m, weapon.MaxRange) && m != defender).ToList();

            int count = list.Count;

            if (count > 0)
            {
                double bushido = attacker.Skills.Bushido.Value;

                //   double damageBonus = 1.0 + Math.Pow((count * bushido) / 60, 2) / 100;

                int damagebonus = 0;

                if (bushido > 0)
                {
                    damagebonus = (int)Math.Min(100, ((list.Count * bushido) * (list.Count * bushido)) / 3600);
                }

                if (damagebonus > 2) damagebonus = 2;

                var context = new WhirlwindAttackContext(attacker, list, damagebonus);
                AddContext(context);

                attacker.RevealingAction();

                foreach (var m in list)
                {
                    attacker.SendLocalizedMessage(1060161); // The whirling attack strikes a target!
                    m.SendLocalizedMessage(1060162); // You are struck by the whirling attack and take damage!

                    weapon.OnHit(attacker, m); // , damageBonus
                }

                RemoveContext(context);
            }

            ColUtility.Free(list);

            weapon.ProcessingMultipleHits = false;
        }

        private static void AddContext(WhirlwindAttackContext context)
        {
            if (Contexts == null)
            {
                Contexts = new List<WhirlwindAttackContext>();
            }

            Contexts.Add(context);
        }

        private static void RemoveContext(WhirlwindAttackContext context)
        {
            if (Contexts != null)
            {
                Contexts.Remove(context);
            }
        }

        public static int DamageBonus(Mobile attacker, Mobile defender)
        {
            if (Contexts == null)
                return 0;

            var context = Contexts.FirstOrDefault(c => c.Attacker == attacker && c.Victims.Contains(defender));

            if (context != null)
            {
                return context.DamageBonus;
            }

            return 0;
        }

        public class WhirlwindAttackContext
        {
            public Mobile Attacker { get; set; }
            public List<Mobile> Victims { get; set; }
            public int DamageBonus { get; set; }

            public WhirlwindAttackContext(Mobile attacker, List<Mobile> list, int bonus)
            {
                Attacker = attacker;
                Victims = list;
                DamageBonus = bonus;
            }
        }
    }
}
