//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Moq;
//using NUnit.Framework;
//using Restauranter.Shared.Extensions;

//namespace Restauranter.Tests.Shared.Extensions
//{
//    [TestFixture]
//    public class IDisposableExtensionsTest
//    {
//        private IList<IDisposable> disposeBag;

//        [SetUp]
//        public void TestSetup()
//        {
//            disposeBag = new List<IDisposable>();
//        }

//        [Test]
//        public void TestForAddingToDisposeBag()
//        {
//            AddToDisposeBag();
//            AddToDisposeBag();
//            AddToDisposeBag();
//            AddToDisposeBag();

//            Assert.AreEqual(4, disposeBag.Count);
//        }

//        [Test]
//        public void TestForNullDisposeBag()
//        {
//            disposeBag = null;

//            Assert.That(() => AddToDisposeBag(),
//                        Throws.TypeOf<ArgumentNullException>());
//        }

//        [Test]
//        public void IsDisposeBagEmptyAfterDispose()
//        {
//            TestForAddingToDisposeBag();

//            disposeBag.Dispose();

//            Assert.IsFalse(disposeBag.Any());
//        }

//        private void AddToDisposeBag()
//        {
//            new Mock<IDisposable>().Object.DisposeIn(disposeBag);
//        }
//    }
//}