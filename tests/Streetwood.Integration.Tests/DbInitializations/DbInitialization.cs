using Streetwood.Core.Domain.Abstract;
using Streetwood.Test.Helpers;

namespace Streetwood.Integration.Tests.DbInitializations
{
    public static class DbInitialization
    {
        public static void InitDb(IDbContext dbContext)
        {
            dbContext.Shipments.AddRange(ShipmentFactory.GetShipments());

            dbContext.Users.Add(UserFactory.CreateUser());

            dbContext.CharmCategories.AddRange(CharmCategoryFactory.GetCharmCategoriesWithCharms(3, 2));



            dbContext.SaveChanges();
        }
    }
}
