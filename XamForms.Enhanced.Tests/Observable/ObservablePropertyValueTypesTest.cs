using NUnit.Framework;
using XamForms.Enhanced.Observable;
using XamForms.Events.Shared;

namespace Restauranter.Tests.Rx
{
    [TestFixture]
    public class ObservablePropertyValueTypesTest
    {
        [Test]
        public void ObservableNullConstructor()
        {
            var observableString = new ObservableProperty<int?>(null);

            Assert.IsNull(observableString.Value);
        }

        [Test]
        public void ObservableDefaultConstructor()
        {
            var observableString = new ObservableProperty<int>();

            Assert.IsNotNull(observableString.Value);
            Assert.AreEqual(default(int), observableString.Value);
        }

        [Test]
        public void ObservableParemterConstructor()
        {
            var expected = 10;
            var observableString = new ObservableProperty<int>(expected);

            Assert.AreEqual(expected, observableString.Value);
        }

        [Test]
        public void ObservableNullConstructorUpdate()
        {
            var observableString = new ObservableProperty<int>();

            var expected = 10;

            observableString.DataChanged += (sender, e) =>
            {
                Assert.AreEqual(expected, observableString.Value);
                Assert.AreEqual(expected, (e as DataEventArgs).Parameter);
            };

            observableString.Value = expected;
            Assert.AreEqual(expected, observableString.Value);
        }

        [Test]
        public void ObservableDefaultConstructorUpdate()
        {
            var observableString = new ObservableProperty<int>();

            var expected = 10;

            observableString.DataChanged += (sender, e) =>
            {
                Assert.AreEqual(expected, observableString.Value);
                Assert.AreEqual(expected, (e as DataEventArgs).Parameter);
            };

            observableString.Value = expected;
            Assert.AreEqual(expected, observableString.Value);
        }

        [Test]
        public void ObservableEmptyStringConstructorUpdate()
        {
            var expected = 2;
            var observableString = new ObservableProperty<int>(expected);

            expected = 10;

            observableString.DataChanged += (sender, e) =>
            {
                Assert.AreEqual(expected, observableString.Value);
                Assert.AreEqual(expected, (e as DataEventArgs).Parameter);
            };

            observableString.Value = expected;
            Assert.AreEqual(expected, observableString.Value);
        }

        [Test]
        public void ObservableStringConstructorUpdate()
        {
            var expected = 2;
            var observableString = new ObservableProperty<int>(expected);
            expected = 10;

            observableString.DataChanged += (sender, e) =>
            {
                Assert.AreEqual(expected, observableString.Value);
                Assert.AreEqual(expected, (e as DataEventArgs).Parameter);
            };

            observableString.Value = expected;
        }
    }
}