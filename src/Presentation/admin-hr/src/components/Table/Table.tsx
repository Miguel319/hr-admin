import { FC } from "react";
import styles from "./table.module.scss";

interface TableProps {
  tableData: any[];
  headingColumns: string[];
  onDelete: (id: string) => Promise<void>;
  onUpdate: (id: string) => void;
}

interface TableRecord {
  key: string;
  val: any;
}

const Table: FC<TableProps> = ({
  headingColumns,
  tableData,
  onDelete,
  onUpdate,
}): JSX.Element => {
  const renderData = () => {
    const data =
      tableData &&
      tableData.length &&
      tableData.map((row, index) => {
        const rowData: TableRecord[] = [];

        Object.entries(row).forEach((data, i) => {
          if (data[0] === "id") return;
          rowData.push({
            key: headingColumns[i],
            val: data[1] as number,
          });
        });
        console.log(row);

        return (
          <tr key={index}>
            {rowData.map((data, index) => (
              <>
                {index === 3 ? (
                  <>
                    <td key={index} data-heading={data.key}>
                      {data.val}
                    </td>
                    <td className="actions">
                      <i
                        className={`fas fa-edit mr-2 ${styles["edit-btn"]}`}
                        onClick={() => onUpdate(`${row.id}/update`)}
                      />
                      <i
                        className={`far fa-trash-alt ${styles["delete-btn"]}`}
                        onClick={() => onDelete(row.id)}
                      ></i>
                    </td>
                  </>
                ) : (
                  <td key={index} data-title={data.key}>
                    {data.val}
                  </td>
                )}
              </>
            ))}
          </tr>
        );
      });

    return data;
  };

  return (
    <div>
      <table className={`${styles["table"]}`}>
        <thead>
          <tr>
            {headingColumns.map((col, index) => (
              <th key={index}>{col}</th>
            ))}
          </tr>
        </thead>
        <tbody>{renderData()}</tbody>
      </table>
    </div>
  );
};

export default Table;
