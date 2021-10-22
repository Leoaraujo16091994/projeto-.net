
using FluentMigrator.Runner.VersionTableInfo;
namespace Crud.WebApi.Migrations

{

    [VersionTableMetaData]
    public class VersionTable : IVersionTableMetaData
    {
        public string ColumnName => "Version";
        public bool OwnsSchema { get; }
        public string SchemaName => "CRUD";
        public string TableName => "FLUENTMIGRATOR_VERSION";
        public string UniqueIndexName => "UC_Version";
        public string AppliedOnColumnName => "AppliedOn";
        public string DescriptionColumnName => "Description";
        public object ApplicationContext { get; set; }
    }
}
