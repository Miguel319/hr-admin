import { NextRouter, useRouter } from "next/router";
import { FC, useState } from "react";
import { PositionRequest } from "../../api/requests/position.request";
import Table from "../../components/Table/Table";
import { IPosition } from "../../models/position.model";
import { DateFormatter } from "../../utils/date-formatter";
import { handleError } from "../../utils/error-handler";

interface DerpartmentsProps {
  positions: Array<IPosition>;
}

const Positions: FC<DerpartmentsProps> = ({ positions }): JSX.Element => {
  const router: NextRouter = useRouter();

  const onDelete = async (id: string) => {
    const alertify = await import("alertifyjs");

    const { notification } = await import("../../utils/notifications");

    alertify.confirm(
      "Are you sure you want to delete this position?",
      async () => {
        try {
          await PositionRequest.delete(id);

          router.replace(router.asPath);

          notification.success("Position deleted successfully!");
        } catch (error) {
          notification.error(handleError(error));
        }
      }
    );
  };

  return (
    <div>
      <div className="flex j-between">
        <h2>Positions</h2>

        <button
          className="outline-btn"
          onClick={() => router.push("/positions/create")}
        >
          <i className=" fas fa-plus-circle mr-1"></i>
          Add
        </button>
      </div>

      <div className="mt-3">
        <Table
          onDelete={onDelete}
          onUpdate={(id: string) => router.push(`/positions/${id}`)}
          entity="position"
          headingColumns={[
            "Name",
            "Min salary",
            "Max salary",
            "Created At",
            "Actions",
          ]}
          tableData={positions.map((v) => ({
            id: v.id,
            name: v.name,
            minSalary: v.minSalary,
            maxSalary: v.maxSalary,
            createdAt: DateFormatter.timeSince(v.createdAt as Date),
          }))}
        ></Table>
      </div>
    </div>
  );
};

export async function getStaticProps() {
  const { data } = await PositionRequest.findAll();

  return {
    props: {
      positions: data,
    },
  };
}

export default Positions;
