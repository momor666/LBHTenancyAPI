using System;
using LBHTenancyAPI.Services;
using Xunit;
using System.Collections.Specialized;
using AgreementService;
using LBHTenancyAPI.Services.Impl;
using LBHTenancyAPI.Settings.Credentials;
using Microsoft.Extensions.Configuration;
using Moq;

namespace LBHTenancyAPITest.Test.Services
{
    public class ArrearsServiceRequestBuilderTests
    {
        private ArrearsServiceRequestBuilder _builder;

        public ArrearsServiceRequestBuilderTests()
        {
            //pre-arrange
            var credentialsService = new Mock<ICredentialsService>();
            _builder = new ArrearsServiceRequestBuilder(credentialsService.Object);
        }

        [Fact]
        public void Throws_If_Null()
        {
            //arrange
            //act
            //assert
            Assert.Throws<ArgumentNullException>(()=>_builder.BuildArrearsRequest(default(WebRequest)));
        }

        [Fact]
        public void Return_A_Built_Request_Object()
        {
            //arrange
            //act
            var request = _builder.BuildArrearsRequest(new ArrearsActionCreateRequest
            {
                ArrearsAction = new ArrearsActionInfo()
            });
            //assert
            Assert.IsType<ArrearsActionCreateRequest>(request);
        }

        [Fact]
        public void WhenGivenActionDiaryDetails_BuildValidArrearsActionDiaryRequest()
        {
            //arrange
            //act
            var request = _builder.BuildArrearsRequest(new ArrearsActionCreateRequest
            {
                ArrearsAction = new ArrearsActionInfo
                {
                    ActionBalance = 17,
                    ActionCode = "GEN",
                    Comment = "Added by webservice",
                    TenancyAgreementRef = "000017/01"
                }
            });
            //assert
            Assert.Equal(17, request.ArrearsAction.ActionBalance);
            Assert.Equal("GEN", request.ArrearsAction.ActionCode);
            Assert.Equal("Added by webservice", request.ArrearsAction.Comment);
            Assert.Equal("000017/01", request.ArrearsAction.TenancyAgreementRef);
        }

        [Fact]
        public void WhenGivenActionDiaryDetails2_BuildValidArrearsActionDiaryRequest()
        {
            //arrange
            //act
            var request = _builder.BuildArrearsRequest(new ArrearsActionCreateRequest
            {
                ArrearsAction = new ArrearsActionInfo
                {
                    ActionBalance = 10,
                    ActionCode = "TEST",
                    Comment = "Testing",
                    TenancyAgreementRef = "000017/02"
                }
            });
            //assert
            Assert.Equal(10, request.ArrearsAction.ActionBalance);
            Assert.Equal("TEST", request.ArrearsAction.ActionCode);
            Assert.Equal("Testing", request.ArrearsAction.Comment);
            Assert.Equal("000017/02", request.ArrearsAction.TenancyAgreementRef);
        }
    }
}
