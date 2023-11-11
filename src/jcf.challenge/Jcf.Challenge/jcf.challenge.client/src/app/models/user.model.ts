export class User {
  constructor(
      public _id: string | null,
      public name: string,
      public email: string | null,
      public password: string | null,
      public firstName: string = ""
  ) { }
}
