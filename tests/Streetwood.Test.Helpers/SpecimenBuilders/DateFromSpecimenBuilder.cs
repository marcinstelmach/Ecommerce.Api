using System;
using System.Reflection;
using AutoFixture.Kernel;

namespace Streetwood.Test.Helpers.SpecimenBuilders
{
    public class DateFromSpecimenBuilder : ISpecimenBuilder
    {
        public object Create(object request, ISpecimenContext context)
        {
            if (!(request is ParameterInfo paramInfo))
            {
                return new NoSpecimen();
            }

            if (paramInfo.ParameterType != typeof(DateTime) && paramInfo.Name != "AvailableFrom")
            {
                return new NoSpecimen();
            }

            return DateTime.Now;
        }
    }
}