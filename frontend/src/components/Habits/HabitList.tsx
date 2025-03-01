import { SimpleGrid } from "@mantine/core";
import { useHabits } from "../../hooks/useHabits";
import { Habit } from "./Habit";

export function HabitList() {
  const { habits, loading, error } = useHabits();

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;

  return (
    <SimpleGrid cols={3} spacing="md">
      {habits.map((habit) => (
        <Habit key={habit.id} habit={habit} />
      ))}
    </SimpleGrid>
  );
}
