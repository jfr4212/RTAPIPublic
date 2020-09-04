using NUnit.Framework;
using System.Collections.Generic;
using RTAPI.Controllers;
using System.Linq;

namespace RTAPI_new.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Get()
        {
            // Arrange
            RightTriangleController RTcontroller = new RightTriangleController();

            // Act
            IEnumerable<string> result = RTcontroller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 1);
            Assert.AreEqual("{\"V1\":{\"X\":0,\"Y\":10},\"V2\":{\"X\":0,\"Y\":0},\"V3\":{\"X\":10,\"Y\":10}}", result.ElementAt(0));
        }

        [Test]
        public void GetByCoordinate()
        {
            // Arrange
            RightTriangleController RTcontroller = new RightTriangleController();

            // Act
            string result = RTcontroller.Get("F7");

            // Assert
            Assert.AreEqual("{\"V1\":{\"X\":30,\"Y\":60},\"V2\":{\"X\":30,\"Y\":50},\"V3\":{\"X\":40,\"Y\":60}}", result);
        }

        [Test]
        public void PostTriangle()
        {
            // Arrange
            RightTriangleController RTcontroller = new RightTriangleController();

            string result = "";
            
            // Act
            result = RTcontroller.Post("{\"V1\":{\"X\":40,\"Y\":50},\"V2\":{\"X\":30,\"Y\":50},\"V3\":{\"X\":40,\"Y\":60}}");

            // Assert
            Assert.AreEqual("F8", result);

            // Act
            result = RTcontroller.Post("{\"V1\":{\"X\":30,\"Y\":60},\"V2\":{\"X\":30,\"Y\":50},\"V3\":{\"X\":40,\"Y\":60}}");

            // Assert
            Assert.AreEqual("F7", result);
        }

    }
}