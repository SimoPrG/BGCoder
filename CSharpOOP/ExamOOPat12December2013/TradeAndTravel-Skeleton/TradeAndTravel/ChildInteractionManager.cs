namespace TradeAndTravel
{
    using System.Linq;

    public class ChildInteractionManager : InteractionManager
    {
        protected override Item CreateItem(string itemTypeString, string itemNameString, Location itemLocation, Item item)
        {
            switch (itemTypeString)
            {
                case "iron":
                    item = new Iron(itemNameString, itemLocation);
                    break;
                case "weapon":
                    item = new Weapon(itemNameString, itemLocation);
                    break;
                case "wood":
                    item = new Wood(itemNameString, itemLocation);
                    break;
                default:
                    item = base.CreateItem(itemTypeString, itemNameString, itemLocation, item);
                    break;
            }
            return item;
        }

        protected override Location CreateLocation(string locationTypeString, string locationName)
        {
            Location location = null;
            switch (locationTypeString)
            {
                case "forest":
                    location = new Forest(locationName);
                    break;
                case "mine":
                    location = new Mine(locationName);
                    break;
                default:
                    location = base.CreateLocation(locationTypeString, locationName);
                    break;
            }
            return location;
        }

        protected override void HandlePersonCommand(string[] commandWords, Person actor)
        {
            switch (commandWords[1])
            {
                case "gather":
                    HandleGatherInteraction(commandWords, actor);
                    break;
                case "craft":
                    HandleCraftInteraction(commandWords, actor);
                    break;
                default:
                    base.HandlePersonCommand(commandWords, actor);
                    break;
            }
        }

        protected virtual void HandleCraftInteraction(string[] commandWords, Person actor)
        {
            switch (commandWords[2])
            {
                case "armor":
                    CraftArmor(commandWords, actor);
                    break;
                case "weapon":
                    CraftWeapon(commandWords, actor);
                    break;
                default:
                    break;
            }
        }

        private void CraftWeapon(string[] commandWords, Person actor)
        {
            if (actor.ListInventory().Any(i => i.ItemType == ItemType.Iron)
                && actor.ListInventory().Any(i => i.ItemType == ItemType.Wood))
            {
                this.AddToPerson(actor, new Weapon(commandWords[3]));
                // TODO: remove iron and wood from inventory
            }
        }

        private void CraftArmor(string[] commandWords, Person actor)
        {
            if (actor.ListInventory().Any(i => i.ItemType == ItemType.Iron))
            {
                this.AddToPerson(actor, new Weapon(commandWords[3]));
                // TODO: remove iron from inventory
            }
        }

        protected virtual void HandleGatherInteraction(string[] commandWords, Person actor)
        {
            if (actor.Location is IGatheringLocation)
            {
                var gatheringLocation = (IGatheringLocation)actor.Location;
                if (actor.ListInventory().Any(i => i.ItemType == gatheringLocation.RequiredItem))
                {
                    this.AddToPerson(actor, gatheringLocation.ProduceItem(commandWords[2]));
                }
            }
        }

        protected override Person CreatePerson(string personTypeString, string personNameString, Location personLocation)
        {
            Person person = null;
            switch (personTypeString)
            {
                case "merchant":
                    person = new Merchant(personNameString, personLocation);
                    break;
                default:
                    person = base.CreatePerson(personTypeString, personNameString, personLocation);
                    break;
            }

            return person;
        }
    }
}
