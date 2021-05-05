using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using DAL.Repository.Boxes;
using DAL.Specifications;
using NUnit.Framework;
using Repository.Tests;
using Repository.Tests.TestCases.Boxes;
using ProductDb.DataClasses;
using Microsoft.EntityFrameworkCore;

namespace Repository.Boxes.Tests
{
    public class RepositoryBoxesTests
    {
        [SetUp]
        public void Setup()
        {
            TestHelper.SeedTestDb();
        }     

        [Test]
        public void DatabaseIsSeeded()
        {
            using (var context = TestHelper.CreateContext())
            {
                Assert.True(context.ProductBrands.Any());
                Assert.True(context.ProductTypes.Any());
                Assert.True(context.Categories.Any());
                Assert.True(context.Products.Any());
                Assert.True(context.Boxes.Any());
                Assert.True(context.BoxProducts.Any());
            }
        }

        // 2 5 9
        //
        [Test]
        [TestCaseSource(typeof(TestCasesBoxes), nameof(TestCasesBoxes.BoxFilterSpecificationCases))]
        public async Task Boxes_GetBoxesWithSpecification_ReturnsListOfBoxes(ValueTuple<BoxFilterSpecification, int> testParams)
        {
            using (var context = TestHelper.CreateContext())
            {
                (var caseSpecification, var expectedCount) = testParams;
                var repository = new Repo(context, null);

                var boxes = await repository.GetBoxesWithSpecification(caseSpecification);

                Assert.NotNull(boxes);
                Assert.IsInstanceOf<IReadOnlyList<Box>>(boxes);
                Assert.AreEqual(expectedCount, boxes.Count);

                foreach (var box in boxes)
                {
                    if (caseSpecification.Params.BrandId is not null) Assert.IsTrue(box.BoxProducts.Any(e => e.Product.ProductBrandId == caseSpecification.Params.BrandId));
                    if (caseSpecification.Params.TypeId is not null) Assert.IsTrue(box.BoxProducts.Any(e => e.Product.ProductTypeId == caseSpecification.Params.TypeId));
                    if (caseSpecification.Params.CategoryId is not null) Assert.IsTrue(box.BoxProducts.Any(e => e.Product.CategoryId == caseSpecification.Params.CategoryId));
                    if (caseSpecification.Params.Search is not null) Assert.IsTrue(box.BoxProducts.Any(e => e.Product.Name.ToLower().Contains(caseSpecification.Params.Search)));
                    if (caseSpecification.Params.Color is not null) Assert.AreEqual((int)box.Color, caseSpecification.Params.Color);
                    if (caseSpecification.Params.Size is not null) Assert.AreEqual((int)box.Size, caseSpecification.Params.Size);
                    Assert.IsInstanceOf<Box>(box);
                } 
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesBoxes), nameof(TestCasesBoxes.SuccessCreateBoxCases))]
        public async Task Boxes_CreateBox_ReturnsTrueIfSucess(Box box)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.CreateBox(box);

                Assert.IsTrue(isSuccess);

                var createdId = context.Boxes.Max(b => b.Id);
                var createdBox = await context.Boxes.FindAsync(createdId);

                Assert.AreEqual(box.Name, createdBox.Name);
                Assert.AreEqual(box.Color, createdBox.Color);
                Assert.AreEqual(box.Size, createdBox.Size);
                Assert.AreEqual(box.Price, createdBox.Price);
                if (box.BoxProducts is not null)
                {
                    for (int i = 0; i < createdBox.BoxProducts.Count; i++)
                    {
                        Assert.AreEqual(box.BoxProducts[i].ProductId, createdBox.BoxProducts[i].ProductId);
                    }
                }
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesBoxes), nameof(TestCasesBoxes.FailCreateBoxCases))]
        public async Task Boxes_CreateBox_ReturnsFalseIfFail(Box box)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.CreateBox(box);

                Assert.IsFalse(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesBoxes), nameof(TestCasesBoxes.SuccessUpdateBoxCases))]
        public async Task Boxes_UpdateBox_ReturnsTrueIfSuccess(Box box)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.UpdateBox(box);

                Assert.IsTrue(isSuccess);

                var updatedBox = await repository.GetBoxById(box.Id);

                Assert.AreEqual(box.Name, updatedBox.Name);
                Assert.AreEqual(box.Color, updatedBox.Color);
                Assert.AreEqual(box.Size, updatedBox.Size);
                Assert.AreEqual(box.Price, updatedBox.Price);
                if (box.BoxProducts is not null)
                {
                    for (int i = 0; i < updatedBox.BoxProducts.Count; i++)
                    {
                        Assert.AreEqual(box.BoxProducts[i].ProductId, updatedBox.BoxProducts[i].ProductId);
                    }
                }
            }
        }
        

        [Test]
        [TestCaseSource(typeof(TestCasesBoxes), nameof(TestCasesBoxes.FailUpdateBoxCases))]
        public async Task Boxes_UpdateBox_ReturnsFalseIfFail(Box Box)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.UpdateBox(Box);

                Assert.IsFalse(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesBoxes), nameof(TestCasesBoxes.SuccessDeleteBoxCases))]
        public async Task Boxes_DeleteBox_ReturnsTrueIfSuccess(int id)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.DeleteBox(id);

                Assert.IsTrue(isSuccess);
            }
        }

        [Test]
        [TestCaseSource(typeof(TestCasesBoxes), nameof(TestCasesBoxes.FailDeleteBoxCases))]
        public async Task Boxes_RemoveBox_ReturnsFalseIfFail(int id)
        {
            using (var context = TestHelper.CreateContext())
            {
                var repository = new Repo(context, null);

                var isSuccess = await repository.DeleteBox(id);

                Assert.IsFalse(isSuccess);
            }
        }

        
    }
}