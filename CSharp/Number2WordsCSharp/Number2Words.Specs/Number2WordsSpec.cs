using Number2Words.Core;
using NUnit.Framework;
using Should;

namespace Number2Words.Specs
{
    [TestFixture]
    class Number2WordsSpec
    {
        [Test]
        public void N0()
        {
            0.ToWords().ShouldEqual("zero");
        }

        [Test]
        public void N1()
        {
            1.ToWords().ShouldEqual("one");
        }

        [Test]
        public void N2()
        {
            2.ToWords().ShouldEqual("two");
        }

        [Test]
        public void N3()
        {
            3.ToWords().ShouldEqual("three");
        }

        [Test]
        public void N4()
        {
            4.ToWords().ShouldEqual("four");
        }

        [Test]
        public void N5()
        {
            5.ToWords().ShouldEqual("five");
        }

        [Test]
        public void N6()
        {
            6.ToWords().ShouldEqual("six");
        }

        [Test]
        public void N7()
        {
            7.ToWords().ShouldEqual("seven");
        }

        [Test]
        public void N8()
        {
            8.ToWords().ShouldEqual("eight");
        }

        [Test]
        public void N9()
        {
            9.ToWords().ShouldEqual("nine");
        }

        [Test]
        public void N10()
        {
            10.ToWords().ShouldEqual("ten");
        }

        [Test]
        public void N11()
        {
            11.ToWords().ShouldEqual("eleven");
        }

        [Test]
        public void N12()
        {
            12.ToWords().ShouldEqual("twelve");
        }

        [Test]
        public void N13()
        {
            13.ToWords().ShouldEqual("thirteen");
        }
        
        [Test]
        public void N14()
        {
            14.ToWords().ShouldEqual("fourteen");
        }
        
        [Test]
        public void N16()
        {
            16.ToWords().ShouldEqual("sixteen");
        }

        [Test]
        public void N19()
        {
            19.ToWords().ShouldEqual("nineteen");
        }

        [Test]
        public void N20()
        {
            20.ToWords().ShouldEqual("twenty");
        }


        [Test]
        public void N21()
        {
            21.ToWords().ShouldEqual("twenty one");
        }

        [Test]
        public void N37()
        {
            37.ToWords().ShouldEqual("thirty seven");
        }

        [Test]
        public void N40()
        {
            40.ToWords().ShouldEqual("forthy");
        }

        [Test]
        public void N59()
        {
            59.ToWords().ShouldEqual("fifty nine");
        }

        [Test]
        public void N60()
        {
           60.ToWords().ShouldEqual("sixty");
        }

        [Test]
        public void N99()
        {
            99.ToWords().ShouldEqual("ninety nine");
        }

        [Test]
        public void N123()
        {
            123.ToWords().ShouldEqual("one hundred twenty three");
        }
    }
}

