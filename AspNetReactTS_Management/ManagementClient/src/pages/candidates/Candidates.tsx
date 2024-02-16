import "./candidates.scss";
import { ICandidate } from "../../types/globalTyping";
import { Button, CircularProgress } from "@mui/material";
import httpModule from "../../helpers/http.module";
import { Add } from "@mui/icons-material";
import CandidatesGrid from "../../components/candidates/CandidatesGrid";
import { useNavigate } from "react-router-dom";
import { useEffect, useState } from "react";

const Candidates: React.FC = () => {
    const [candidates, setcandidates] = useState<ICandidate[]>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const redirect = useNavigate();

    useEffect(() => {
        setLoading(true);
        httpModule
            .get<ICandidate[]>("/candidate/Get")
            .then((res) => {
                setcandidates(res.data);
                setLoading(false);
            })
            .catch((error) => {
                alert("Error");
                console.log(error);
                setLoading(false);
            });
    }, []);
    return (
        <div className="content candidates">
            <div className="heading">
                <h2>candidates</h2>
                <Button variant="outlined" onClick={() => redirect("/candidates/add")}>
                    <Add />
                </Button>
            </div>
            {loading ? (
                <CircularProgress size={100} />
            ) : candidates.length === 0 ? (
                <h1>No candidate</h1>
            ) : (
                <CandidatesGrid data={candidates} />
            )}
        </div>
    );
};

export default Candidates;
