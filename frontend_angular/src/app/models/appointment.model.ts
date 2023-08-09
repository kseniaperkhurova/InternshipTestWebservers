export class Appointment {
  id: string;
  startTime: string;
  endTime: string;
  name: string;
  discipline: string;

  constructor(
    id: string,
    name: string,
    startTime: string,
    endTime: string,
    discipline: string
  ) {
    this.id = id;
    this.name = name;
    this.startTime = startTime;
    this.endTime = endTime;
    this.discipline = discipline;
  }
}
