import React, { useState } from "react";
import "./companies.scss";
import { ICreateCompanyDto } from "../../types/globalTyping";
import { Button, FormControl, InputLabel, MenuItem, Select, TextField } from "@mui/material";
import httpModule from "../../helpers/http.module";
import { useNavigate } from "react-router-dom";

const AddCompany: React.FC = () => {
    const [company, setCompany] = useState<ICreateCompanyDto>({
        name: "",
        size: "",
    });

    const redirect = useNavigate();

    const saveBtn = () => {
        if (company.name === "" || company.size === "") {
            alert("Bos alanlari doldurunuz");
            return;
        }
        httpModule
            .post("/Company/Create", company)
            .then(() => redirect("/companies"))
            .catch((error) => console.log(error));
    };

    const backBtn = () => {
        redirect("/companies");
    };

    return (
        <div className="content">
            <div className="add-company">
                <h2>Add New Company</h2>
                <TextField
                    autoComplete="off"
                    label="Company Name"
                    variant="outlined"
                    value={company.name}
                    onChange={(e) => setCompany({ ...company, name: e.target.value })}
                />
                <FormControl fullWidth>
                    <InputLabel>Company Size</InputLabel>
                    <Select
                        value={company.size}
                        label="Company Size"
                        onChange={(e) => setCompany({ ...company, size: e.target.value })}
                    >
                        <MenuItem value="Small">Small</MenuItem>
                        <MenuItem value="Medium">Medium</MenuItem>
                        <MenuItem value="Large">Large</MenuItem>
                    </Select>
                </FormControl>
                <div className="btns">
                    <Button variant="outlined" color="primary" onClick={saveBtn}>
                        Save
                    </Button>
                    <Button variant="outlined" color="secondary" onClick={backBtn}>
                        Back
                    </Button>
                </div>
            </div>
        </div>
    );
};

export default AddCompany;
