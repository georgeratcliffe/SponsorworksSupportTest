export interface Ticket {
  id: number;
  title: string;
  description: string;
  userId: number;
  user: {
    id: number;
    name: string;
    email: string;
  };
  status: string;
  priority: string;
  createdDate: string;
  updatedDate?: string;
}
