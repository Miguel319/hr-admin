import { NextRouter, useRouter } from "next/router";
import { FC, useEffect, useState } from "react";
import { useForm, useWatch } from "react-hook-form";
import { DepartmentRequest } from "../../../api/requests/department.request";
import { IDepartment, NewDepartment } from "../../../models/derpartment.model";
import styles from "../../../styles/form.module.scss";
import { handleError } from "../../../utils/error-handler";

const Update: FC = (): JSX.Element => {
  const router: NextRouter = useRouter();
  const [error, setError] = useState<any>();
  const [isPending, setIsPending] = useState<boolean>(false);
  const { id } = router.query;
  const [department, setDepartment] = useState<IDepartment | null>(null);

  useEffect(() => {
    const fetchDepartment = async () => {
      const { data } = await DepartmentRequest.findById(id as string);

      setDepartment(data);
    };

    fetchDepartment();
  }, []);

  const {
    register,
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<NewDepartment>({
    mode: "onBlur",
  });

  const name = useWatch({
    control,
    name: "name",
  });

  const code = useWatch({
    control,
    name: "code",
  });

  useEffect(() => {
    setError(null);
  }, [name, code]);

  const onSubmit = handleSubmit(async (data) => {
    const { notification } = await import("../../../utils/notifications");

    try {
      setIsPending(true);

      await DepartmentRequest.update(id as string, data as IDepartment);

      notification.success("Department updated successfully!");

      setTimeout(() => router.push("/departments"), 500);
    } catch (error) {
      setError(handleError(error));
    } finally {
      setIsPending(false);
    }
  });

  return (
    <div className={`${styles[""]}`}>
      <h2>Update Department</h2>

      <form onSubmit={onSubmit} className={`${styles["form"]} mt-3`}>
        {department ? (
          <>
            <div className={`${styles["form-group"]}`}>
              <label htmlFor="name">Name</label>
              <input
                type="text"
                {...register("name", {
                  required: "The name is mandatory.",
                })}
                name="name"
                defaultValue={department.name}
                placeholder="Department"
              />
              {errors.name ? (
                <span className="error-msg">{errors.name.message}</span>
              ) : null}
            </div>

            <div className={`${styles["form-group"]}`}>
              <label htmlFor="code">Code</label>
              <input
                type="text"
                defaultValue={department.code}
                name="code"
                {...register("code", {
                  required: "The code is mandatory.",
                })}
                placeholder="AB2-42"
              />
              {errors.code ? (
                <span className="error-msg">{errors.code.message}</span>
              ) : null}
            </div>
            {error ? <p className="error-msg">{error}</p> : null}

            <button>
              {isPending ? (
                <>
                  <div className="animate-spin mr-3">
                    <i className="fas fa-spinner"></i>
                  </div>
                  <span>Loading...</span>
                </>
              ) : null}
              Update Department
            </button>
          </>
        ) : null}
      </form>
    </div>
  );
};

export default Update;
