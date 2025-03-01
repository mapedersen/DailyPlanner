import { MantineProvider } from "@mantine/core";
import "@mantine/core/styles.css";
import "./App.css";
import { HabitList } from "./components/Habits/HabitList";

function App() {
  return (
    <MantineProvider defaultColorScheme="dark">
      <HabitList />
    </MantineProvider>
  );
}

export default App;
