using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;

namespace BookServiceTest
{
    class MoqDataAttribute : AutoDataAttribute
    {
        public MoqDataAttribute()
        : base(() => new Fixture().Customize(new AutoMoqCustomization()))
        {
        }
    }
}
