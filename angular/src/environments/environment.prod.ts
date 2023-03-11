const port = '5000';
const host = 'https://car-debate.herokuapp.com';
const host2 = 'http://localhost';
export const environment = {
  production: true,
  apiUrl: `${host2}:${port}/api`,
  // apiUrl: `${host}/api`,
  hubUrl: `${host}:${port}`,
};
