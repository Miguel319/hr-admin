interface NavLink {
  url: string;
  title: string;
}

export const navLinks: NavLink[] = [
  { url: "/", title: "Home" },
  { url: "/deparments", title: "Deparments" },
  { url: "/employees", title: "Employees" },
  { url: "/auth/sign-up", title: "Sign Up" },
];
