import { NextRouter, useRouter } from "next/router";
import { FC, useState } from "react";
import { DepartmentRequest } from "../../api/requests/department.request";
import Table from "../../components/Table/Table";
import { IDepartment } from "../../models/derpartment.model";
import { DateFormatter } from "../../utils/date-formatter";
import { handleError } from "../../utils/error-handler";

interface DerpartmentsProps {
  departments: Array<IDepartment>;
}

const Departments: FC<DerpartmentsProps> = ({ departments }): JSX.Element => {
  const router: NextRouter = useRouter();

  const onDelete = async (id: string) => {
    const alertify = await import("alertifyjs");

    const { notification } = await import("../../utils/notifications");

    alertify.confirm(
      "Are you sure you want to delete this department?",
      async () => {
        try {
          await DepartmentRequest.delete(id);

          router.replace(router.asPath);

          notification.success("Department deleted successfully!");
        } catch (error) {
          notification.error(handleError(error));
        }
      }
    );
  };

  return (
    <div>
      <div className="flex j-between">
        <h2>Departments</h2>

        <button
          className="outline-btn"
          onClick={() => router.push("/departments/create")}
        >
          <i className=" fas fa-plus-circle mr-1"></i>
          Add
        </button>
      </div>

      <div className="mt-3">
        <Table
          onDelete={onDelete}
          onUpdate={(id: string) => router.push(`/departments/${id}`)}
          headingColumns={[
            "Name",
            "Code",
            "Created At",
            "Updated At",
            "Actions",
          ]}
          tableData={departments.map((v) => ({
            id: v.id,
            name: v.name,
            code: v.code,
            createdAt: DateFormatter.timeSince(v.createdAt as Date),
            updatedAt: DateFormatter.timeSince(v.updatedAt as Date),
          }))}
        ></Table>
      </div>
    </div>
  );
};

export async function getStaticProps() {
  const { data } = await DepartmentRequest.findAll();

  return {
    props: {
      departments: data,
    },
  };
}

export default Departments;
