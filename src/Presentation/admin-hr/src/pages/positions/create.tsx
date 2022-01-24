import { NextRouter, useRouter } from "next/router";
import { FC, useEffect, useState } from "react";
import { useForm, useWatch } from "react-hook-form";
import { PositionRequest } from "../../api/requests/position.request";
import { IPosition, INewPosition } from "../../models/position.model";
import styles from "../../styles/form.module.scss";
import { handleError } from "../../utils/error-handler";

const create: FC = (): JSX.Element => {
  const router: NextRouter = useRouter();
  const [error, setError] = useState<any>();
  const [isPending, setIsPending] = useState<boolean>(false);

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

  const onSubmit = handleSubmit(async (position): Promise<void> => {
    const { notification } = await import("../../utils/notifications");
    try {
      setIsPending(true);

      await PositionRequest.create(position as IPosition);

      notification.success("Position created successfully");

      setTimeout(() => router.push("/positions"), 800);
    } catch (error) {
      setError(handleError(error));
    } finally {
      setIsPending(false);
    }
  });

  return (
    <div className={`${styles[""]}`}>
      <h2>Create Position</h2>

      <form onSubmit={onSubmit} className={`${styles["form"]} mt-3`}>
        <div className={`${styles["form-group"]}`}>
          <label htmlFor="name">Name</label>
          <input
            type="text"
            {...register("name", {
              required: "The name is mandatory.",
            })}
            name="name"
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
            name="minSalary"
            {...register("minSalary", {
              required: "The min salary is mandatory.",
            })}
            placeholder="2000"
          />
          {errors.minSalary ? (
            <span className="error-msg">{errors.minSalary.message}</span>
          ) : null}
        </div>

        <div className={`${styles["form-group"]}`}>
          <label htmlFor="code">Max Salary</label>
          <input
            type="number"
            name="maxSalary"
            {...register("maxSalary", {
              required: "The max salary is mandatory.",
            })}
            placeholder="5000"
          />
          {errors.maxSalary ? (
            <span className="error-msg">{errors.maxSalary.message}</span>
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
          Create Position
        </button>
      </form>
    </div>
  );
};

export default create;
