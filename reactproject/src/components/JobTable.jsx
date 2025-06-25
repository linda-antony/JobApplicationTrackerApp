import React, { useState } from "react";
import "../css/JobTable.css";

function JobTable({ jobs, onEdit }) {
    const [currentPage, setCurrentPage] = useState(1);
    const jobsPerPage = 5;

    // Sort by date (descending), then by company name
    const sortedJobs = [...jobs].sort((a, b) => {
        const dateA = new Date(a.applicationDate);
        const dateB = new Date(b.applicationDate);

        if (dateA > dateB) return -1;
        if (dateA < dateB) return 1;

        const companyA = a.companyName || '';
        const companyB = b.companyName || '';
        return companyA.localeCompare(companyB, undefined, { sensitivity: 'base' });
    });


    // Calculate pagination
    const totalPages = Math.ceil(jobs.length / jobsPerPage);
    const startIndex = (currentPage - 1) * jobsPerPage;
    const currentJobs = sortedJobs.slice(startIndex, startIndex + jobsPerPage);

    const handlePrevious = () => {
        setCurrentPage((prev) => Math.max(prev - 1, 1));
    };

    const handleNext = () => {
        setCurrentPage((prev) => Math.min(prev + 1, totalPages));
    };

    return (
        <div className="table-container">
            <table className="job-table">
                <thead>
                    <tr>
                        <th>Company Name</th>
                        <th>Position</th>
                        <th>Status</th>
                        <th>Date Applied</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>
                    {currentJobs.length > 0 ? (
                        currentJobs.map((job) => (
                            <tr key={job.id}>
                                <td style={{ display: 'none' }}>
                                    <input type="hidden" value={job.id} />
                                </td>
                                <td>{job.companyName}</td>
                                <td>{job.position}</td>
                                <td>
                                    <span className={`status ${job.status.toLowerCase()}`}>
                                        {job.status}
                                    </span>
                                </td>
                                <td>{new Date(job.applicationDate).toLocaleDateString('en-NZ')}</td>
                                <td>
                                    <button
                                        className="edit-btn"
                                        onClick={() => onEdit(job)}>
                                        Edit
                                    </button>
                                </td>
                            </tr>
                        ))) : (
                        <tr>
                            <td colSpan="5" style={{ textAlign: "center" }}>
                                No job applications found.
                            </td>
                        </tr>
                    )}
                </tbody>
            </table>

            {/* Pagination Controls */}
            <div className="pagination">
                <button onClick={handlePrevious} disabled={currentPage === 1}>
                    ⬅ Previous
                </button>
                <span>Page {currentPage} of {totalPages || 1}</span>
                <button onClick={handleNext} disabled={currentPage === totalPages || totalPages === 0}>
                    Next ➡
                </button>
            </div>
        </div>
    );
}

export default JobTable;
