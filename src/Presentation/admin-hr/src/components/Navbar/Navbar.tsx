import { FC, useState } from "react";
import { navLinks } from "../../utils/constants";
import styles from "./navbar.module.css";
import Link from "next/link";
import { useRouter } from "next/router";

const Navbar: FC = (): JSX.Element => {
  const [clicked, setClicked] = useState<boolean>(false);
  const router: NextRouter = useRouter();

  const toggleClick = (): void => setClicked(!clicked);

  const Links: JSX.Element[] = navLinks.map(({ title, url }, idx) => (
    <li key={idx} onClick={() => (clicked ? toggleClick() : null)}>
      <Link href={url}>
        <a>{title}</a>
      </Link>
    </li>
  ));

  return (
    <nav className={`${styles["navbar"]}`}>
      <div className={`${styles["navbar-container"]}`}>
        <div className={`${styles["logo"]}`} onClick={() => router.push("/")}>
          Admin <span className={`${styles["effect"]}`}>HR</span>
        </div>
        <div className={`${styles["menu-bar"]}`} onClick={toggleClick}>
          <i className="fas fa-bars" />
        </div>
        <ul
          className={`${styles["navbar-items"]} ${
            clicked ? "" : styles["close"]
          }`}
        >
          {Links}
        </ul>
      </div>
    </nav>
  );
};

export default Navbar;
