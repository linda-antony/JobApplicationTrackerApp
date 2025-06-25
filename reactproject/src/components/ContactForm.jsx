import React, { useEffect, useState } from 'react';
import axios from 'axios';

const ContactForm = ({ addJob, editingJob, cancelEdit }) => {
    const getTodayDate = () => new Date().toISOString().split("T")[0];

    useEffect(() => {
        if (editingJob) {
            setFormData(editingJob);
        }
    }, [editingJob]);

    const [formData, setFormData] = useState({
        id: 0,
        companyName: '',
        position: '',
        status: 'Applied',
        applicationDate: getTodayDate(),
    });

    const handleCancel = () => {
        setFormData({
            id: 0,
            companyName: '',
            position: '',
            status: 'Applied',
            applicationDate: getTodayDate(),
        });
        cancelEdit();
    };

    const handleChange = (e) => {
        setFormData(prev => ({
            ...prev,
            [e.target.name]: e.target.value
        }));
    };

    const handleSubmit = async (e) => {
        e.preventDefault();

        const method = editingJob ? 'put' : 'post';
        const url = editingJob
            ? 'https://localhost:7045/applications/update'
            : 'https://localhost:7045/applications';

        try {
            const response = await axios({
                method,
                url,
                data: formData,
                headers: {
                    'Content-Type': 'application/json'
                }
            });

            if (response.status === 200 || response.status === 201) {
                const newJob = response.data;
                addJob(newJob);

                setFormData({
                    id: 0,
                    companyName: '',
                    position: '',
                    status: 'Applied',
                    applicationDate: getTodayDate(),
                });
            } else {
                alert('Failed to submit form.');
            }
        } catch (err) {
            console.error('Error submitting form:', err);
        }
    };


    return (
        <form onSubmit={handleSubmit}>
            <input type="hidden" name="id" value={formData.id || ''} />
            <input
                type="text"
                name="companyName"
                placeholder="Company Name"
                value={formData.companyName}
                onChange={handleChange}
                required
                pattern=".*\S.*"
                title="Company name must contain at least one non-whitespace character"
            />
            <input
                type="text"
                name="position"
                placeholder="Job Position"
                value={formData.position}
                onChange={handleChange}
                required
                pattern=".*\S.*"
                title="Job position must contain at least one non-whitespace character"
            />
            <select name="status" value={formData.status} onChange={handleChange}>
                <option>Applied</option>
                <option>Interview</option>
                <option>Offer</option>
                <option>Rejected</option>
            </select>
            <input
                type="date"
                name="applicationDate"
                value={new Date(formData.applicationDate).toISOString().split("T")[0]}
                onChange={handleChange}
                max={getTodayDate()} // restricts future dates
                required
            />
            <button type="submit">{editingJob ? 'Update Job' : 'Add Job'}</button>
            {editingJob && (
                <button type="button" onClick={handleCancel} style={{ backgroundColor: '#6c757d', marginLeft: '10px' }}>
                    Cancel
                </button>
            )}
        </form>
    );
};

export default ContactForm;
