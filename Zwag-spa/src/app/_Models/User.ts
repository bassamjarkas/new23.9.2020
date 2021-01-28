import { Photo } from './photo';
export interface User {
id:number;
username:string;
age:number;
knowas:string;
gender:string;
created:Date;
lastActive:Date;
photoUrl:string;
city:string;
country:string;
intersstes?:string;
introduction?:string;
lookingFor?:string;
photos?:Photo[];
}
