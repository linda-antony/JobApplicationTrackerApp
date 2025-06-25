import React, { useEffect, useState } from 'react';
import axios from 'axios';
import ContactForm from './ContactForm';
import JobTable from './JobTable';
import "../css/JobTable.css";

function App() {
    const [products, setProducts] = useState([]);
    const [editingJob, setEditingJob] = useState(null);

    useEffect(() => {
        axios.get('https://localhost:7045/applications')
            .then(response => {
                setProducts(response.data);
            })
            .catch(error => {
                console.error('Error fetching products:', error);
            });
    }, []);  

    const addJob = (job) => {

        if (editingJob) {
            // Update job
            setProducts((prev) =>
                prev.map((j) => (j.id === editingJob.id ? { ...job, id: editingJob.id } : j))
            );
            setEditingJob(null); // Exit edit mode
        }
        else {
            // Add new job
            const newJob = { ...job, id: job.id };
            setProducts((prev) => [newJob, ...prev]);       
        }
    };

    const handleEdit = (job) => {
        setEditingJob(job);
        window.scrollTo({ top: 0, behavior: "smooth" }); // Scroll to form
    };

    return (
        <>
            <div className="App">
                <div className="logo-title">
                    <img src="/main-logo.png" alt="Logo" className="logo" />
                    <h1 className="page-title">Job Application Tracker</h1>
                </div>
            </div>

            <ContactForm addJob={addJob} editingJob={editingJob} cancelEdit={() => setEditingJob(null)} />
            <JobTable jobs={products} onEdit={handleEdit} />   
        </>
    );    
};

export default App;



