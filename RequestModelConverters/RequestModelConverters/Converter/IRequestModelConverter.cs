namespace RequestModelConverters.Converter
{
    public interface IRequestModelConverter<T>
    {
        T ConvertRequestModel(object obj);
    }
}
