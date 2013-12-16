using System;
using Moq;
using NUnit.Framework;
using TheMvcApp.Aspects.AspectArgumentAdapters;
using TheMvcApp.Aspects.AspectConcerns;

namespace TheMvcApp.Tests.Aspects.AspectArgumentAdapters
{
    [TestFixture]
    public class AngularAntiForgeryTokenAttributeAspectConcernTests
    {
        private Mock<IAngularAntiForgeryTokenArgumentAdapter> _adapter;
        private IAngularAntiForgeryTokenAttributeAspectConcern _concern;

        [SetUp]
        public void SetUp()
        {
            _adapter = new Mock<IAngularAntiForgeryTokenArgumentAdapter>();
            _adapter.Setup(a => a.TokenFromHeader).Returns("ValidToken");
            _adapter.Setup(a => a.TokenFromCookie).Returns("ValidToken");


            _concern = new AngularAntiForgeryTokenAttributeAspectConcern();

        }

        [Test]
        public void OnEntry_ThrowsException_WhenNoTokenFoundInHeader()
        {
            // Arrange
            _adapter.Setup(a => a.TokenFromHeader).Returns(string.Empty);

            // Act Assert
            Assert.Throws<Exception>(() => _concern.OnEntry(_adapter.Object));

            // Assert
            // Assert.That(_adapter.Object.FlowBehavior, Is.Not.EqualTo(FlowBehavior.Continue));
        }
        
        [Test]
        public void OnEntry_ThrowsException_WhenNoTokenFoundInCookie()
        {
            // Arrange
            _adapter.Setup(a => a.TokenFromCookie).Returns(string.Empty);

            // Act Assert
            Assert.Throws<Exception>(() => _concern.OnEntry(_adapter.Object));

            // Assert
            // Assert.That(_adapter.Object.FlowBehavior, Is.Not.EqualTo(FlowBehavior.Continue));
        }

        [Test]
        public void OnEntry_FlowContinues_WhenCookieAndTokenMatch()
        {
            // Arrange

            //FlowBehavior? flowBehavior = null;
            //_adapter.Setup(a => a.FlowBehavior = It.IsAny<FlowBehavior>()).Callback((FlowBehavior b) => flowBehavior = b);

            // Act
            Assert.DoesNotThrow(() => _concern.OnEntry(_adapter.Object));

            // Assert
            // Assert.That(flowBehavior, Is.EqualTo(FlowBehavior.Continue));
        }
    }
}
