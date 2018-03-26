using NUnit.Framework;
using XamForms.Enhanced.Observable;
using XamForms.Events.Shared;

namespace Restauranter.Tests.Rx
{
    [TestFixture]
    public class ObservablePropertyStringTest
    {
        [Test]
        public void ObservableDefaultConstructor()
        {
            var observableString = new ObservableProperty<string>();

            Assert.IsNull(observableString.Value);
        }

        [Test]
        public void ObservableNullConstructor()
        {
            var observableString = new ObservableProperty<string>(null);

            Assert.IsNull(observableString.Value);
        }

        [TestCase("")]
        [TestCase("test")]
        public void ObservableStringInConstructor(string input)
        {
            var observableString = new ObservableProperty<string>(input);

            Assert.AreEqual(input, observableString.Value);
        }

        [Test]
        public void ObservableDefaultConstructorUpdate()
        {
            var observableString = new ObservableProperty<string>();

            var expected = "test";

            observableString.DataChanged += (sender, e) =>
            {
                Assert.AreEqual(expected, observableString.Value);
                Assert.AreEqual(expected, (e as DataEventArgs).Parameter);
            };

            observableString.Value = expected;
            Assert.AreEqual(expected, observableString.Value);
        }

        [Test]
        public void ObservableNullConstructorUpdate()
        {
            var observableString = new ObservableProperty<string>(null);

            var expected = "test";

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
            var expected = string.Empty;
            var observableString = new ObservableProperty<string>(expected);

            expected = "test";

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
            var expected = "test";
            var observableString = new ObservableProperty<string>(expected);
            expected = "test2";

            observableString.DataChanged += (sender, e) =>
            {
                Assert.AreEqual(expected, observableString.Value);
                Assert.AreEqual(expected, (e as DataEventArgs).Parameter);
            };

            observableString.Value = expected;
        }
    }
}