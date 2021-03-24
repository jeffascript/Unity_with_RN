/**
 * Sample React Native App
 * https://github.com/facebook/react-native
 *
 * @format
 * @flow
 */

import React from 'react';
import {StyleSheet, View} from 'react-native';

import {Colors} from 'react-native/Libraries/NewAppScreen';
// import UnityView, {UnityModule} from '@asmadsen/react-native-unity-view';
import UnityView from '@asmadsen/react-native-unity-view';

const UnityScreen: () => React$Node = () => {
  // your other code
  return (
    <View style={styles.container}>
      <UnityView
        style={{position: 'absolute', left: 0, right: 0, top: 1, bottom: 1}}
      />
    </View>
  );
};

export default UnityScreen;

const styles = StyleSheet.create({
  container: {
    flex: 1,
    flexDirection: 'column',
    justifyContent: 'center',
    alignItems: 'center',
    backgroundColor: 'yellow',
  },
  scrollView: {
    backgroundColor: Colors.lighter,
  },
  engine: {
    position: 'absolute',
    right: 0,
  },
  body: {
    backgroundColor: Colors.white,
  },
  sectionContainer: {
    marginTop: 32,
    paddingHorizontal: 24,
  },
  sectionTitle: {
    fontSize: 24,
    fontWeight: '600',
    color: Colors.black,
  },
  sectionDescription: {
    marginTop: 8,
    fontSize: 18,
    fontWeight: '400',
    color: Colors.dark,
  },
  highlight: {
    fontWeight: '700',
  },
  footer: {
    color: Colors.dark,
    fontSize: 12,
    fontWeight: '600',
    padding: 4,
    paddingRight: 12,
    textAlign: 'right',
  },
});
