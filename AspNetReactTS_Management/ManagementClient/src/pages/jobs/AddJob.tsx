import { useState, useEffect } from "react";
import "./job.scss";
import { ICompany, ICreateJobDto } from "../../types/globalTyping";
import TextField from "@mui/material/TextField/TextField";
import FormControl from "@mui/material/FormControl/FormControl";
import InputLabel from "@mui/material/InputLabel/InputLabel";
import Select from "@mui/material/Select/Select";
import MenuItem from "@mui/material/MenuItem/MenuItem";
import Button from "@mui/material/Button/Button";
import { useNavigate } from "react-router-dom";
import httpModule from "../../helpers/http.module";

const levelsArray: string[] = ["Intern", "Junior", "MidLevel", "Senior", "TeamLead", "Cto", "Architect"];

const AddJob = () => {
    const [job, setJob] = useState<ICreateJobDto>({
        title: "",
        level: "",
        companyId: "",
    });
    const [companies, setCompanies] = useState<ICompany[]>([]);

    const redirect = useNavigate();

    useEffect(() => {
        httpModule
            .get<ICompany[]>("/Company/Get")
            .then((res) => {
                setCompanies(res.data);
            })
            .catch((error) => {
                alert("Hata Olustu");
                console.log(error);
            });
    }, []);

    const save = () => {
        if (job.title === "" || job.level === "" || job.companyId === "") {
            alert("Bos alanlari doldurunuz");
            return;
        }
        httpModule
            .post("/Job/Create", job)
            .then(() => redirect("/jobs"))
            .catch((error) => console.log(error));
    };

    const back = () => {
        redirect("/jobs");
    };

    return (
        <div className="content">
            <div className="add-job">
                <h2>Add New Job</h2>
                <TextField
                    autoComplete="off"
                    label="Job Title"
                    variant="outlined"
                    value={job.title}
                    onChange={(e) => setJob({ ...job, title: e.target.value })}
                />

                <FormControl fullWidth>
                    <InputLabel>Job Level</InputLabel>
                    <Select value={job.level} label="Job Level" onChange={(e) => setJob({ ...job, level: e.target.value })}>
                        {levelsArray.map((item) => (
                            <MenuItem key={item} value={item}>
                                {item}
                            </MenuItem>
                        ))}
                    </Select>
                </FormControl>

                <FormControl fullWidth>
                    <InputLabel>Company</InputLabel>
                    <Select
                        value={job.companyId}
                        label="Company"
                        onChange={(e) => setJob({ ...job, companyId: e.target.value })}
                    >
                        {companies.map((item) => (
                            <MenuItem key={item.id} value={item.id}>
                                {item.name}
                            </MenuItem>
                        ))}
                    </Select>
                </FormControl>

                <div className="btns">
                    <Button variant="outlined" color="primary" onClick={save}>
                        Save
                    </Button>
                    <Button variant="outlined" color="secondary" onClick={back}>
                        Back
                    </Button>
                </div>
            </div>
        </div>
    );
};

export default AddJob;