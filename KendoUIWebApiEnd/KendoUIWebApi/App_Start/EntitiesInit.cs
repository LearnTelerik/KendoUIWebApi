using System.Collections.Generic;
using System.Data.Entity;
using KendoUIWebApi.Models;

namespace KendoUIWebApi.App_Start
{
    public class EntitiesInit : DropCreateDatabaseAlways<KendoUIWebApiContext>
    {
        protected override void Seed(KendoUIWebApiContext context)
        {
            var foos = new List<Foo>
                           {
                               new Foo {Name = "Red"},
                               new Foo {Name = "Green"},
                               new Foo {Name = "Blue"},
                               new Foo {Name = "Yellow"},
                               new Foo {Name = "Orange"}
                           };

            foos.ForEach(f => context.Foos.Add(f));

            base.Seed(context);
        }
    }
}