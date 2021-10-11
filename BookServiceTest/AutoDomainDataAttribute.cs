using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;
using BookService.Controllers;
using BookServiceTest.Controllers;


namespace BookServiceTest
{
    class AutoDomainDataAttribute : AutoDataAttribute
    {

        internal class ApiControllerConventions : CompositeCustomization
        {
            internal ApiControllerConventions()
                : base(
                    new ApiControllerCustomization(),
                    new AutoMoqCustomization())
            {
            }
        }

        private class ApiControllerCustomization : ICustomization
        {
            public void Customize(IFixture fixture)
            {
                fixture.Customize<BooksController>(c => c.OmitAutoProperties());
            }
        }

        public AutoDomainDataAttribute()
            :base(() => new Fixture().Customize(new ApiControllerConventions()))
        {
        }

    }
}
