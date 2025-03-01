export interface Habit {
  id: number;
  name: string;
  description: string;
  createdAt: string;
}

export interface HabitResponse {
  habits: Habit[];
}
