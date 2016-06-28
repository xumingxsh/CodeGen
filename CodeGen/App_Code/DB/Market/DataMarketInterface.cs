using System;
using System.Data;


public interface DataMarketInterface
{
    DataSet TableDataSet
    {
        get;
        set;
    }

    void SetTableDataSetNull();

    DataView GetColumnsForTable(int tableId);

    DataView GetColumnsForUser();

    DataView GetColumnsForTable(string tableName);

    DataView GetColumnForProduce(int id);

    DataView GetUserTable();

    DataView GetProduce();

    DataView GetView();

    DataView GetTableFK(int tableId);

    DataView GetFKFromTable(int tableId);

    DataView GetFKFromTable(string tableName);

    DataTable GetTablePK(string tableName);

    DataRowView GetTableInfo(string tableName);

    DataRowView GetTableInfo(int tableId);

    bool IsPKForColumn(string tableName, string columnName);

    bool IsFKForColumn(string tableName, string columnName);

    DataRowView GetColumn(string tableName, string columnName);

    string GetProduce(int id);

    string GetView(int id);

    void ReadColumnDT(ColumnDT dt, DataRow dv);

    void ReadFKDT(FKDT dt, DataRow drv);

    void ReadPKDT(PKDT dt, DataRow dr);

    void ReadTableDT(TableExpandDT dt, DataRow dr);

    DataTable ExecuteDataTable(string sql);

    int ExecuteNoQuery(string sql);

    string GetPVAFContent(int id);
}