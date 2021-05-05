using System;
using System.Collections.Generic;
using DAL;
using DAL.Specifications;
using NUnit.Framework;
using ProductDb.DataClasses;
using ProductDb.DataClasses.Enums;

namespace Repository.Tests.TestCases.Boxes
{
    [TestFixture]
    public static class TestCasesBoxes
    {
        public static IEnumerable<Box> SuccessCreateBoxCases()
        {
            yield return new Box { Name = "New Box 1", Price = 100, BoxProducts = new List<BoxProduct> {
                new BoxProduct { ProductId = 1 },
                new BoxProduct { ProductId = 2 },
                new BoxProduct { ProductId = 3 },
            }};
            yield return new Box { Name = "New Box 2", Price = 300, Color = BoxColor.Black, BoxProducts = new List<BoxProduct> {
                new BoxProduct { ProductId = 1 },
                new BoxProduct { ProductId = 2 },
                new BoxProduct { ProductId = 3 },
            }};
            yield return new Box { Name = "New Box 3", Price = 100, Color = BoxColor.Green, Size = BoxSize.Medium, BoxProducts = new List<BoxProduct> {
                new BoxProduct { ProductId = 1 },
                new BoxProduct { ProductId = 2 },
                new BoxProduct { ProductId = 3 },
            }};
        }

        public static IEnumerable<Box> FailCreateBoxCases()
        {
            yield return null;
            yield return new Box { Id = 1, Name = "New Box 1", Price = 100, Color = BoxColor.Green, Size = BoxSize.Medium, BoxProducts = new List<BoxProduct> {
                new BoxProduct { ProductId = 1 },
                new BoxProduct { ProductId = 2 },
                new BoxProduct { ProductId = 3 },
            }};
        }

        public static IEnumerable<Box> SuccessUpdateBoxCases()
        {
            yield return new Box { Id = 1, Name = "Changed" };
            yield return new Box { Id = 2, Name = "Changed 2", BoxProducts = new List<BoxProduct> {
                new BoxProduct { BoxId = 2, ProductId = 1 },
                new BoxProduct { BoxId = 2, ProductId = 1 },
                new BoxProduct { BoxId = 2, ProductId = 1 },
            }};
            yield return new Box { Id = 3, Name = "Changed 3", Color = BoxColor.Black, BoxProducts = new List<BoxProduct> {
                new BoxProduct { BoxId = 3, ProductId = 3 },
                new BoxProduct { BoxId = 3, ProductId = 3 },
                new BoxProduct { BoxId = 3, ProductId = 3 },
            }};
        }

        public static IEnumerable<Box> FailUpdateBoxCases()
        {
            yield return new Box { Id = 99 };
            yield return new Box();
            yield return null;
        }

        public static IEnumerable<int> SuccessDeleteBoxCases()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }
        
        public static IEnumerable<int> FailDeleteBoxCases()
        {
            yield return -1;
            yield return 99;
            yield return 0;
        }

        public static IEnumerable<(BoxFilterSpecification, int)> BoxFilterSpecificationCases()
        {
            yield return (new BoxFilterSpecification(new BoxProductParams()), 4);
            yield return (new BoxFilterSpecification(new BoxProductParams { BrandId = 1 }), 4);
            yield return (new BoxFilterSpecification(new BoxProductParams { BrandId = 2 }), 4);
            yield return (new BoxFilterSpecification(new BoxProductParams { BrandId = 3 }), 4);
            yield return (new BoxFilterSpecification(new BoxProductParams { TypeId = 1 }), 4);
            yield return (new BoxFilterSpecification(new BoxProductParams { TypeId = 2 }), 4);
            yield return (new BoxFilterSpecification(new BoxProductParams { TypeId = 3 }), 4);
            yield return (new BoxFilterSpecification(new BoxProductParams { CategoryId = 1 }), 4);
            yield return (new BoxFilterSpecification(new BoxProductParams { CategoryId = 2 }), 4);
            yield return (new BoxFilterSpecification(new BoxProductParams { CategoryId = 3 }), 4);
            yield return (new BoxFilterSpecification(new BoxProductParams { BrandId = 1, TypeId = 1, CategoryId = 1 }), 4);
            yield return (new BoxFilterSpecification(new BoxProductParams { BrandId = 1, TypeId = 2, CategoryId = 3 }), 4);
            yield return (new BoxFilterSpecification(new BoxProductParams { Search = "Product 1" }), 3);
            yield return (new BoxFilterSpecification(new BoxProductParams { Search = "Product" }), 4);
            yield return (new BoxFilterSpecification(new BoxProductParams { Search = "0" }), 1);
            yield return (new BoxFilterSpecification(new BoxProductParams { Color = 1 }), 1);
            yield return (new BoxFilterSpecification(new BoxProductParams { Size = 1 }), 2);
            yield return (new BoxFilterSpecification(new BoxProductParams { Size = 1, Color = 1 }), 0);
            yield return (new BoxFilterSpecification(new BoxProductParams { BrandId = 1, Search = "Dummy"  }), 0);
            yield return (new BoxFilterSpecification(new BoxProductParams { CategoryId = 2, Search = "Dummy"  }), 0);
            yield return (new BoxFilterSpecification(new BoxProductParams { Search = "Box", PageSize = 2  }), 0);
            yield return (new BoxFilterSpecification(new BoxProductParams { Search = "Box"  }), 0);
        }
    }
}