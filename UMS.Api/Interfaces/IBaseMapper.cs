namespace UMS.Api.Interfaces
{
    public interface IBaseMapper<TSource, TDestination>
    {
        TDestination MapModel(TSource source);
        TDestination MapModel(TSource source, TDestination destination);
        IEnumerable<TDestination> MapList(IEnumerable<TSource> source);
    }
}
