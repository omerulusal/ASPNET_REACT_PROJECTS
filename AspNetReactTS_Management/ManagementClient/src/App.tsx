import React, { Suspense, lazy, useContext } from "react";
import { ThemeContext } from "./context/theme";
import Navbar from "./components/navbar/Navbar";
import { Routes, Route } from "react-router-dom";
import Jobs from "./pages/jobs/Jobs";
import Candidates from "./pages/candidates/Candidates";
import CustomLinearProgress from "./components/linearProgress/LinearProgress";
import AddCompany from "./pages/companies/AddCompany";
import AddJob from "./pages/jobs/AddJob";
import AddCandidate from "./pages/candidates/AddCandidate";

const Home = lazy(() => import("./pages/home/Home"));
const Companies = lazy(() => import("./pages/companies/Companies"));
//yuklenme işlemini biraz yavaslattım


const App: React.FC = () => {
  const { darkMode } = useContext(ThemeContext);
  const appStyle = darkMode ? "app dark" : "app";

  return (
    <div className={appStyle}>
      <Navbar />
      <div className="wrapper">
        <Suspense fallback={<CustomLinearProgress />}>
          <Routes>
            <Route path="/" element={<Home />} />
            <Route path="/companies">
              <Route index element={<Companies />} />
              <Route path="add" element={<AddCompany />} />
            </Route>
            <Route path="/jobs">
              <Route index element={<Jobs />} />
              <Route path="add" element={<AddJob />} />
            </Route>
            <Route path="/candidates">
              <Route index element={<Candidates />} />
              <Route path="add" element={<AddCandidate />} />
            </Route>
          </Routes>
        </Suspense>
      </div>
    </div>
  );
};

export default App;
