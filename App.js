/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 * @flow
 */

import React from 'react';

import {NavigationContainer} from '@react-navigation/native';
import MyStack from './src/MyStack';

const App = () => {
  return (
    <>
      <NavigationContainer>
        <MyStack />
      </NavigationContainer>
    </>
  );
};

export default App;
