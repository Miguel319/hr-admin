interface NavLink {
  url: string;
  title: string;
}

export const navLinks: NavLink[] = [
  { url: "/", title: "Home" },
  { url: "/departments", title: "Departments" },
  { url: "/employees", title: "Employees" },
  { url: "/auth/sign-up", title: "Sign Up" },
];

export const API_URL = String(process.env["NEXT_PUBLIC_API_URL"]);
