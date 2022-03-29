namespace GenericsANDTypeParametrs
{
    internal interface IWriteDataRepository<in T> // it enables to return  less derived types that specified by generic parameter
    {
        void AddData(T data);
        void DeleteData(T data);
    }
}
