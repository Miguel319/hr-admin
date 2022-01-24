import { NextRouter, useRouter } from "next/router";
import { FC, useEffect, useState } from "react";
import { useForm, useWatch } from "react-hook-form";
import { PositionRequest } from "../../../api/requests/position.request";
import { IPosition, INewPosition } from "../../../models/position.model";
import styles from "../../../styles/form.module.scss";
import { handleError } from "../../../utils/error-handler";

const Update: FC = (): JSX.Element => {
  const router: NextRouter = useRouter();
  const [error, setError] = useState<any>();
  const [isPending, setIsPending] = useState<boolean>(false);
  const { id } = router.query;
  const [position, setPosition] = useState<IPosition | null>(null);

  useEffect(() => {
    const fetchPosition = async () => {
      const { data } = await PositionRequest.findById(id as string);

      setPosition(data);
    };

    fetchPosition();
  }, []);

  const {
    register,
    handleSubmit,
    control,
    formState: { errors },
  } = useForm<INewPosition>({
    mode: "onBlur",
  });

  const name = useWatch({
    control,
    name: "name",
  });

  const minSalary = useWatch({
    control,
    name: "minSalary",
  });

  const maxSalary = useWatch({
    control,
    name: "maxSalary",
  });

  useEffect(() => {
    setError(null);
  }, [name, minSalary, maxSalary]);

  const onSubmit = handleSubmit(async (data) => {
    const { notification } = await import("../../../utils/notifications");

    try {
      setIsPending(true);

      await PositionRequest.update(id as string, data as IPosition);

      notification.success("Position updated successfully!");

      setTimeout(() => router.push("/positions"), 500);
    } catch (error) {
      setError(handleError(error));
    } finally {
      setIsPending(false);
    }
  });

  return (
    <div className={`${styles[""]}`}>
      <h2>Update Position</h2>

      <form onSubmit={onSubmit} className={`${styles["form"]} mt-3`}>
        {position ? (
          <>
            <div className={`${styles["form-group"]}`}>
              <label htmlFor="name">Name</label>
              <input
                type="text"
                {...register("name", {
                  required: "The name is mandatory.",
                })}
                name="name"
                defaultValue={position.name}
                placeholder="Position"
              />
              {errors.name ? (
                <span className="error-msg">{errors.name.message}</span>
              ) : null}
            </div>

            <div className={`${styles["form-group"]}`}>
              <label htmlFor="minSalary">Min Salary</label>
              <input
                type="number"
                defaultValue={position.minSalary}
                name="minSalary"
                {...register("minSalary", {
                  required: "The code is mandatory.",
                })}
                placeholder="2000"
              />
              {errors.minSalary ? (
                <span className="error-msg">{errors.minSalary.message}</span>
              ) : null}
            </div>

            <div className={`${styles["form-group"]}`}>
              <label htmlFor="minSalary">Max Salary</label>
              <input
                type="number"
                defaultValue={position.maxSalary}
                name="code"
                {...register("maxSalary", {
                  required: "The max salary is mandatory.",
                })}
                placeholder="5000"
              />
              {errors.minSalary ? (
                <span className="error-msg">{errors.minSalary.message}</span>
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
              Update Position
            </button>
          </>
        ) : null}
      </form>
    </div>
  );
};

export default Update;
