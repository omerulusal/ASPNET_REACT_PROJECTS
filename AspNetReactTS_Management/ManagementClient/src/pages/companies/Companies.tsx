import React, { useEffect, useState } from "react";
import "./companies.scss";
import httpModule from "../../helpers/http.module";
import { ICompany } from "../../types/globalTyping";
import { Button, CircularProgress } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { Add } from "@mui/icons-material";
import CompaniesGrid from "../../components/companies/CompaniesGrid";

const Companies: React.FC = () => {
    const [companies, setCompanies] = useState<ICompany[]>([]);
    const [loading, setLoading] = useState<boolean>(false);
    const redirect = useNavigate();
    useEffect(() => {
        setLoading(true);
        httpModule
            .get<ICompany[]>("/Company/Get")
            .then((res) => {
                setCompanies(res.data);
                setLoading(false);
            })
            .catch((err) => {
                console.log(err);
                setLoading(false);
            });
    }, []);
    console.log(companies);

    return (
        <div className="content companies">
            <div className="heading">
                <h2>Companies</h2>
                <Button variant="contained" onClick={() => redirect("/companies/add")}>
                    <Add />
                </Button>
            </div>
            {loading ? (
                <CircularProgress size={100} />
            ) : companies.length === 0 ? (
                <h2>No Company</h2>
            ) : (
                <CompaniesGrid data={companies} />
            )}
        </div>
    );
};

export default Companies;
