(function() {
    'use strict';
    
    console.log('Angular app loading...');
    
    function loadTickets() {
        fetch('/api/tickets')
            .then(response => response.json())
            .then(tickets => {
                const tbody = document.querySelector('tbody');
                if (tbody) {
                    tbody.innerHTML = tickets.map(ticket => `
                        <tr>
                            <td>${ticket.Id}</td>
                            <td>${ticket.Title}</td>
                            <td>${ticket.User?.Name || ''}</td>
                            <td>${ticket.Status}</td>
                            <td>${ticket.Priority}</td>
                            <td>${new Date(ticket.CreatedDate).toLocaleDateString()}</td>
                        </tr>
                    `).join('');
                }
            })
            .catch(error => console.error('Error loading tickets:', error));
    }
    
    document.addEventListener('DOMContentLoaded', function() {
        const appRoot = document.querySelector('app-root');
        if (appRoot) {
            appRoot.innerHTML = `
                <h1>Support Helpdesk</h1>
                <div>
                    <h2>Support Tickets</h2>
                    <table>
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Title</th>
                                <th>User</th>
                                <th>Status</th>
                                <th>Priority</th>
                                <th>Created</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr><td colspan="6">Loading...</td></tr>
                        </tbody>
                    </table>
                </div>
            `;
            loadTickets();
        }
    });
})();
