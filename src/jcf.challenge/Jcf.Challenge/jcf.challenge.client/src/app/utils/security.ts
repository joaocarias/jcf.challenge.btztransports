import { User } from "../models/user.model";

export class Security {
  public static set(user: User, token: string) {
    const data = JSON.stringify(user);

    localStorage.setItem('jcf-challenge-user', btoa(data));
    localStorage.setItem('jcf-challenge-token', token);
  }

  public static setUser(user: User) {
    const data = JSON.stringify(user);
    localStorage.setItem('jcf-challenge-user', btoa(data));
  }

  public static setToken(token: string) {
    localStorage.setItem('jcf-challenge-token', token);
  }

  public static getUser(): User | null {
    const data = localStorage.getItem('jcf-challenge-user');
    if (data) {
      return JSON.parse(atob(data));
    }
    return null;
  }

  public static getToken(): string | null {
    const data = localStorage.getItem('jcf-challenge-token');
    if (data) {
      return data;
    }
    return null;
  }

  public static hasToken(): boolean {
    if (this.getToken())
      return true;
    else
      return false;
  }

  public static clear() {
    localStorage.removeItem('jcf-challenge-user');
    localStorage.removeItem('jcf-challenge-token');
  }
}
