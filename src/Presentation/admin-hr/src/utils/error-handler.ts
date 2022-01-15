import { AxiosError } from "axios";

export const handleError = (error: AxiosError) => {
  const { data } = error.response;

  if (data.errors) {
    const stateErrors = [];

    for (const key in data.errors) {
      if (data.errors[key]) stateErrors.push(data.errors[key]);
    }

    return stateErrors.flat();
  }

  return data;
};
