using System.Collections.Generic;

namespace Library.Items.ExceptionalItems
{
    public class DarkSword : AbstractItem
    {
        private List<ElementalGem> Gems { get; } = new List<ElementalGem>();
        public DarkSword(List<ElementalGem> gems) : base(0, 0, 0)
        {
            foreach (var gem in gems)
            {
                this.DamageValue += gem.DamageValue;
                this.DefenseValue += gem.DefenseValue;
                this.HealthValue += gem.HealthValue;
                Gems.Add(gem);
            }
        }

        public override string ToString()
        {
            return "Dark sword";
        }

        public DarkSword Combine(ElementalGem gem)
        {
            var gems = this.Gems;
            gems.Add(gem);
            return new DarkSword(gems);
        }
        
    }
}