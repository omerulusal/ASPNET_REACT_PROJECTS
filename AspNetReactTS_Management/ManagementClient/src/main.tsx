import ReactDOM from "react-dom/client";
import App from "./App.tsx";
import "./global.scss";
import ThemeContextProvider from "./context/theme.tsx";
import { BrowserRouter } from "react-router-dom";

ReactDOM.createRoot(document.getElementById("root")!).render(
  <ThemeContextProvider>
    <BrowserRouter>
      <App />
    </BrowserRouter>
  </ThemeContextProvider>
);
