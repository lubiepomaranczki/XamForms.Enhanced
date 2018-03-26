using NUnit.Framework;
using XamForms.Enhanced.Observable;
using XamForms.Events.Shared;

namespace Restauranter.Tests.Rx
{
    [TestFixture]
    public class ObservablePropertyComplexObjectTest
    {
        [Test]
        public void ObservableNullConstructor()
        {
            var observable = new ObservableProperty<MockedComplexObject>(null);

            Assert.IsNull(observable.Value);
        }

        [Test]
        public void ObservableDefaultConstructor()
        {
            var observable = new ObservableProperty<MockedComplexObject>();

            Assert.IsNull(observable.Value);
        }

        [Test]
        public void ObservableParemterConstructor()
        {
            var expected = new MockedComplexObject();
            var observable = new ObservableProperty<MockedComplexObject>(expected);

            Assert.IsNotNull(observable.Value);
            Assert.AreEqual(expected, observable.Value);
        }

        [Test]
        public void ObservableNullConstructorUpdate()
        {
            var observable = new ObservableProperty<MockedComplexObject>(null);

            var expected = new MockedComplexObject();

            observable.DataChanged += (sender, e) =>
            {
                Assert.AreEqual(expected, observable.Value);
                Assert.AreEqual(expected, (e as DataEventArgs).Parameter);
            };

            observable.Value = expected;
            Assert.AreEqual(expected, observable.Value);
        }

        [Test]
        public void ObservableDefaultConstructorUpdate()
        {
            var observable = new ObservableProperty<MockedComplexObject>();

            var expected = new MockedComplexObject();

            observable.DataChanged += (sender, e) =>
            {
                Assert.AreEqual(expected, observable.Value);
                Assert.AreEqual(expected, (e as DataEventArgs).Parameter);
            };

            observable.Value = expected;
            Assert.AreEqual(expected, observable.Value);
        }

        [Test]
        public void ObservableParameterConstructorUpdate()
        {
            var expected = new MockedComplexObject();
            var observable = new ObservableProperty<MockedComplexObject>(expected);

            expected = new MockedComplexObject();
            expected.TestString.Value = "test";

            observable.DataChanged += (sender, e) =>
            {
                Assert.AreEqual(expected, observable.Value);
                Assert.AreEqual(expected, (e as DataEventArgs).Parameter);
                Assert.AreEqual(expected.TestString.Value, ((e as DataEventArgs).Parameter as MockedComplexObject).TestString.Value);
            };

            observable.Value = expected;
            Assert.AreEqual(expected, observable.Value);
        }

        private class MockedComplexObject
        {
            public ObservableProperty<string> TestString { get; set; } = new ObservableProperty<string>("testString");
        }
    }
}