import Head from "next/head";
import Navbar from "../components/Navbar/Navbar";
import "../styles/globals.scss";
import "notyf/notyf.min.css";
import "alertifyjs/build/css/alertify.css";

function MyApp({ Component, pageProps }) {
  return (
    <>
      <Head>
        <link
          rel="stylesheet"
          href="https://pro.fontawesome.com/releases/v5.10.0/css/all.css"
          integrity="sha384-AYmEC3Yw5cVb3ZcuHtOA93w35dYTsvhLPVnYs9eStHfGJvOvKxVfELGroGkvsg+p"
          crossOrigin="anonymous"
        />
        <link
          rel="stylesheet"
          href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.2/css/all.min.css"
        />
      </Head>

      <Navbar />

      <div className="container">
        <Component {...pageProps} />
      </div>
    </>
  );
}

export default MyApp;
