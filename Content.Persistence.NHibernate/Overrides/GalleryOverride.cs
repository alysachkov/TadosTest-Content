namespace Content.Persistence.NHibernate.Overrides
{
    using Domain.Entities;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Automapping.Alterations;
    using Types;


    public class GalelryOverride : IAutoMappingOverride<Gallery>
    {
        public void Override(AutoMapping<Gallery> mapping)
        {
            mapping.Map(x => x.ImagesUrls).CustomType<StringListJsonCustomType>();
        }
    }
}